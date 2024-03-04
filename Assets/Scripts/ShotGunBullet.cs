using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ShotGunBullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject explosion;
    public GameObject bulletHole;
    public AudioSource source;
    public AudioClip enemyHitSound;

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
        if (other.gameObject.name.Contains("Enemy"))
        {
            source.PlayOneShot(enemyHitSound);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Instantiate(bulletHole, transform.position, other.transform.rotation);
        }
        var health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(10);
        }
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        //transform.forward = other.contacts[0].normal;
    }
}
