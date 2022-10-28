using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    DeathHandler deathHandler;

    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    public void TakeEnemyDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        Debug.Log($"Player health: {playerHealth}");
        if (playerHealth <= 0)
        {
            deathHandler.HandleDeath();
            Debug.Log($"Player has died");
        }
    }

}
