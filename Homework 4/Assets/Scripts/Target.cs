using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private int _mouseBtn = -1;
    private LineRenderer _lineRenderer;
    public NavMeshAgent playerAgent;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update ()
    {
        HotKeys(); 
        DrawLine();
    }

    private bool GetInput(ref int btn)
    {
        if(Input.GetMouseButtonDown(0))
        {
            btn = 0;
            return true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            btn = 1;
            return true;
        }
        return false;
    }

    private void DrawLine()
    {
        if (playerAgent.hasPath)
        {
            _lineRenderer.positionCount = playerAgent.path.corners.Length;
            _lineRenderer.SetPositions(playerAgent.path.corners);
            _lineRenderer.enabled = true;
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
    private void HotKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Keypad1)))
        {
            float min = 0;
            Vector3 target = new Vector3();
            bool index = false;
            foreach (var i in GameManager.Instance.neutralVillages)
            {
                if (!index)
                {
                    min = Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position);
                    index = true;
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }
                else if (Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position) < min)
                {
                    min = Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position);
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }

            }       
            GameManager.Instance.SetTarget(target);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || (Input.GetKeyDown(KeyCode.Keypad2)))
        {
            float min = 0;
            Vector3 target = new Vector3();
            bool index = false;
            foreach (var i in GameManager.Instance.enemyVillages)
            {
                if (!index)
                {
                    min = Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position);
                    index = true;
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }
                else if (Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position) < min)
                {
                    min = Vector3.Distance(GameManager.Instance.player.transform.position, i.transform.position);
                    target = i.GetComponent<Village>().spawnPosition.position ;
                }

            }       
            GameManager.Instance.SetTarget(target);
        }
        if(GetInput(ref _mouseBtn)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
            {
                Vector3 targetPosition = hitInfo.point;
                if (_mouseBtn == 1)
                {
                    GameManager.Instance.player.GetComponent<Bot>().agent.stoppingDistance =
                    Vector3.Distance(GameManager.Instance.player.transform.position, targetPosition) * 0.98f;
                }
                else if (_mouseBtn == 0)
                {
                    GameManager.Instance.player.GetComponent<Bot>().agent.stoppingDistance = 1;
                    GameManager.Instance.player.GetComponent<Bot>().agent.speed = 10;
                }
                GameManager.Instance.SetTarget(targetPosition);
            }
        }
    }
}

