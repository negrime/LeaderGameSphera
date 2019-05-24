using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public GameObject explosion;
    void Start()
    {
  
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.down * 10000);
    }

    
    private void OnCollisionEnter(Collision other)
    {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
            gameObject.GetComponent<SphereCollider>().enabled = true;
            StartCoroutine(EnableCollider());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && gameObject.GetComponent<SphereCollider>().enabled && other.gameObject.name != "EnemyBoss")
        {
            other.GetComponent<Bot>().Die(other.gameObject);
            GameManager.Instance.RemoveUnit("Enemy");
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject);
    }
}
