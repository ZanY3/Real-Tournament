using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target == null) target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        agent.destination = target.position;
    }
}
