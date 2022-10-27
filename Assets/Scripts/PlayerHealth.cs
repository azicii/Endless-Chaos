using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void TakeEnemyDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        Debug.Log($"Player health: {playerHealth}");
        if (playerHealth <= 0)
        {
            Debug.Log($"Player has died");
        }
    }

}
