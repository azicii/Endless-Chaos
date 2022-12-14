using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] float timeBeforeDestroy = 3f;
    Animator animator;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        //BroadcastMessage method invokes the method in quotes on all scripts attached to the gameobject and to any of its children. Works similarly to just doing GetComponent<EnemyAI>().OnDamageTaken(); but can be invoked in multiple scripts at once. 
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        Debug.Log($"{this.name} health: {hitPoints}");
        if (hitPoints <= 0)
        {
            animator.SetTrigger("isDead");
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        Destroy(gameObject, timeBeforeDestroy);
    }
}
