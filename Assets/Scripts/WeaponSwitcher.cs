using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int weaponIndex;

    void Start()
    {
        SetWeaponActive();
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