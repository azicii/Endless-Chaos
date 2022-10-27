using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float attackDamage = 10f;

    void Start()
    {
        


    }

    void AttackHitEvent()
    {
        if (player == null) { return; }

        Debug.Log("bamgobamgoBAMGO");
    }
    
}
