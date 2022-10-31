using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    Weapon weapon;

    void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    public void lowerAmmoAmount()
    {
        ammoAmount--;
    }

    public int currentAmmoCapacity()
    {
        return ammoAmount;
    }
}
