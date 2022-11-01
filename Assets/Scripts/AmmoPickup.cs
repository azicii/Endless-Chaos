using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.2f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pickup aqcuired");
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
