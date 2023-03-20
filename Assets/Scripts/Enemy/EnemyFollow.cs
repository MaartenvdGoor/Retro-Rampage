using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;

    public FollowRadius FollowRadius;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (FollowRadius.canFollowPlayer)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(player.transform.position);
    }
}