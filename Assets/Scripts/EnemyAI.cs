using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float attackDistance = 1f;
    Animator animator;

    NavMeshAgent navMeshAgent;
    //Use Mathf.Infinity this so that the enemyAI doesn't instantiate thinking that its distanceToTarget is 0
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        animator.SetBool("isMoving", true);
        animator.SetBool("isAttacking", false);
        
        navMeshAgent.SetDestination(target.position);
        
        if (distanceToTarget >= chaseRange)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isMoving", false);
        }
    }

    void AttackTarget()
    {
        animator.SetBool("isAttacking", true);

        Debug.Log("HIYA");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
