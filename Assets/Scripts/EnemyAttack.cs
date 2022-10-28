using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth player;
    [SerializeField] float attackDamage = 10f;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    void AttackHitEvent()
    {
        if (player == null) { return; }

        player.TakeEnemyDamage(attackDamage);
    }
}
