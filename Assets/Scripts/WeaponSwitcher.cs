using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int weaponIndex;
    PlayerZoom scope;

    void Start()
    {
        SetWeaponActive();
        scope = GetComponent<PlayerZoom>();
    }

    void Update()
    {
        int previousWeapon = weaponIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != weaponIndex)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponIndex = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (weaponIndex >= transform.childCount - 1)
            {
                weaponIndex = 0;
            }
            else
            {
                weaponIndex++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (weaponIndex == 0)
            {
                weaponIndex = transform.childCount - 1;
            }
            else
            {
                weaponIndex--;
            }
        }
    }

    private void SetWeaponActive()
    {
        int currentWeapon = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            currentWeapon++;
        }
    }
}
