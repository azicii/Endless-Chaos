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
    EnemyHealth health;
    //Use Mathf.Infinity this so that the enemyAI doesn't instantiate thinking that its distanceToTarget is 0
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    [SerializeField] float turnSpeed = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }
    
    void Update()
    {
        if (health.IsDead())
        {
            navMeshAgent.enabled = false;
            enabled = false;
        }

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
        FaceTarget();
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
        navMeshAgent.SetDestination(target.position);

        animator.SetTrigger("isMoving");
        animator.SetBool("isAttacking", false);
    }

    void AttackTarget()
    {
        animator.SetBool("isAttacking", true);
    }

    void FaceTarget()
    {
        //direction variable of type vector3 gives us the direction that we want this gameobject to rotate with magnitude of 1 (.normalized)
        Vector3 direction = (target.position - transform.position).normalized;
        //lookRotation variable of type quaternion gives us the rotation that we want this gameobject to make. where do we need to rotate essentially. 
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //Quaternion.Slerp lets us rotate smoothly (spherical interpolation) between 2 vectors. 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
}
