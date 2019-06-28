using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnHouse : MonoBehaviour 
{
    public GameObject ally;
    private Animator _anim;
    private void Start() 
    {
       _anim = gameObject.GetComponent<Animator>();
    }


    private void OnMouseDown() 
    {
        _anim.SetTrigger("Spawn");
        int a = Random.Range(1, 3) % 2 == 0 ? 1 : -1;
        Instantiate(ally, new Vector3(transform.position.x + Random.Range(5, 25) * a, transform.position.y, transform.position.z+ Random.Range(5, 30) * a), Quaternion.identity);
    }
}