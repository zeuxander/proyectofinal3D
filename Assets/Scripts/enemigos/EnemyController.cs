using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int curentPatrolPoints;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(patrolPoints[curentPatrolPoints].position);

        if(agent.remainingDistance <= 2f)
        {
            curentPatrolPoints++;
            if (curentPatrolPoints >= patrolPoints.Length)
            {
                curentPatrolPoints = 0;
            }
            agent.SetDestination(patrolPoints[curentPatrolPoints].position);
        }
    }
}
