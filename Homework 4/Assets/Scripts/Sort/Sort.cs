using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sort : MonoBehaviour
{
    private Vector3 _lastPos;
    private bool kek;

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 playerPos = GameManager.Instance.player.transform.position;
            playerPos.x += 3;
            for (int i = 0; i < GameManager.Instance.allyes.Count; i++)
            {
                if (i == 0)
                {
                    GameManager.Instance.allyes[i].agent.SetDestination(playerPos);
                }
                else
                {
                    GameManager.Instance.allyes[i].agent
                        .SetDestination(new Vector3(_lastPos.x + 2, _lastPos.y, _lastPos.z));
                }

                GameManager.Instance.allyes[i].transform.eulerAngles =
                    GameManager.Instance.player.transform.eulerAngles;
                _lastPos = GameManager.Instance.allyes[i].agent.destination;
            }
            print("FINISH");
        }

        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(SimpleSort());


    }



    IEnumerator SimpleSort()
    {
        Ally temp;
        for (int i = 0; i < GameManager.Instance.allyes.Count-1; i++)
        {
            
            for (int j = i + 1; j < GameManager.Instance.allyes.Count; j++)
            {
                GameManager.Instance.allyes[i].rankTxt.color = Color.red;
                GameManager.Instance.allyes[j].rankTxt.color = Color.green;
                if (GameManager.Instance.allyes[i].rank < GameManager.Instance.allyes[j].rank)
                {
                    GameManager.Instance.allyes[i].rankTxt.color = Color.black;
                   temp = GameManager.Instance.allyes[i];
                    GameManager.Instance.allyes[i].agent
                        .SetDestination(GameManager.Instance.allyes[j].transform.position);
                    print("switch");
                    GameManager.Instance.allyes[i].rankTxt.color = Color.black;
                    GameManager.Instance.allyes[j].rankTxt.color = Color.red;
                    GameManager.Instance.allyes[j].agent
                        .SetDestination(temp.transform.position);
                    print("switch2");
                    yield return new WaitUntil((() => GameManager.Instance.allyes[j].agent.hasPath && GameManager.Instance.allyes[i].agent.hasPath));
                    GameManager.Instance.allyes[i] = GameManager.Instance.allyes[j];
                    GameManager.Instance.allyes[j] = temp;
                    print("here");
                    yield return new WaitForSeconds(2f);
                    print("oop");
                }
                print("here");
                yield return new WaitForSeconds(1f);
                print("oop");
                GameManager.Instance.allyes[j].rankTxt.color = Color.black;
                
            }
            GameManager.Instance.allyes[i].rankTxt.color = Color.black;
            Z();
            yield return  new WaitForSeconds(1);

        }

    }

    private void Z()
    {
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        playerPos.x += 3;
        for (int i = 0; i < GameManager.Instance.allyes.Count; i++)
        {
            if (i == 0)
            {
                GameManager.Instance.allyes[i].agent.SetDestination(playerPos);
            }
            else
            {
                GameManager.Instance.allyes[i].agent
                    .SetDestination(new Vector3(_lastPos.x + 2, _lastPos.y, _lastPos.z));
            }

            GameManager.Instance.allyes[i].transform.eulerAngles =
                GameManager.Instance.player.transform.eulerAngles;
            _lastPos = GameManager.Instance.allyes[i].agent.destination;
        }
        print("FINISH");
    }
    
}





