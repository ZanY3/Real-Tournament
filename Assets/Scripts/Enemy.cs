using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public AudioSource source;
    public AudioClip hitClip;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target == null) target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        agent.destination = target.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            source.PlayOneShot(hitClip);
        }
    }
}
