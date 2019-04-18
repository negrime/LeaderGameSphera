using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int enemyAmount;

    public int playerAmount;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
