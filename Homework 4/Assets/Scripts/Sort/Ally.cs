using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ally : MonoBehaviour
{
    public NavMeshAgent agent;
    public int rank;
    private Transform _txtPos;
    public Text rankTxt;
    public Transform canvas;
    private Transform _txt;
    void Start()
    {
        _txtPos = GetComponentInChildren<Transform>();
        rank = Random.Range(0, 50);
        agent = GetComponent<NavMeshAgent>();
        GameManager.Instance.allyes.Add(this);
        canvas = GameObject.Find("Canvas").transform;
        rankTxt = Instantiate(rankTxt, _txtPos.position, Quaternion.identity, canvas);
        rankTxt.text = rank.ToString();
    }

    void Update()
    {
        rankTxt.transform.position = transform.position;
    }
}
