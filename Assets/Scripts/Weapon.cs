using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffectVFX;
    [SerializeField] Ammo ammoSlot;

    GameObject parentGameObject;


    void Start()
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (ammoSlot.currentAmmoCapacity() > 0)
        {
            muzzleFlash.Play();
            ProcessRaycast();
            ammoSlot.lowerAmmoAmount();
        }
        else { return; }
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log($"Player has hit: {hit.transform.name}");
            CreateHitImpact(hit);
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

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));
        impact.transform.parent = parentGameObject.transform;

    }
}
