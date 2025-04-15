using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
 public NavMeshAgent agent;
    public Transform[] transforms;

    int currentTransfromtIndex;
    private void Start()
    {
        agent.SetDestination(transforms[0].position);    
    }
    private void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            currentTransfromtIndex=(currentTransfromtIndex+1)% transforms.Length;
            agent.SetDestination(transforms[currentTransfromtIndex].position);   
        }
    }

}
