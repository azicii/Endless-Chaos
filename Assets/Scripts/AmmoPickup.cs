using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.2f;
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pickup aqcuired");
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType, ammoAmount);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
