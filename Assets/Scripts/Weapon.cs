using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log($"Player has hit: {hit.transform.name}");
            if (hit.transform.gameObject.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.TakeDamage(weaponDamage);
            }
        }
        else
        {
            return;
        }
    }
}
