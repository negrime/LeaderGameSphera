using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public GameObject explosion;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
            gameObject.GetComponent<SphereCollider>().enabled = true;
            StartCoroutine(EnableCollider());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && gameObject.GetComponent<SphereCollider>().enabled)
        {
            other.GetComponent<Bot>().Die(other.gameObject);
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("huy");
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }
}
