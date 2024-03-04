using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    
    public float speed = 20;
    public GameObject explosion;
    public GameObject bulletHole;

    void Start()
    {
        //Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name.Contains("Wall"))
        {
            Instantiate(bulletHole, transform.position, transform.rotation);
        }
        var health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(15);
        }
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        //transform.forward = other.contacts[0].normal;
    }
}


