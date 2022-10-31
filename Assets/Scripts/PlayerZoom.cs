using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField] Camera FPScamera;
    [SerializeField] float zoomedInCamera = 12f;
    [SerializeField] float zoomedOutCamera = 60f;
    [SerializeField] float ZoomedSensitivity = 0.5f;
    [SerializeField] float UnzoomedSensitivity = 2f;

    bool togglePlayerZoom = false;
    RigidbodyFirstPersonController movementScript;

    void Start()
    {
        movementScript = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (togglePlayerZoom == false)
            {
                togglePlayerZoom = true;
                FPScamera.fieldOfView = zoomedInCamera;
                movementScript.mouseLook.XSensitivity = ZoomedSensitivity;
                movementScript.mouseLook.YSensitivity = ZoomedSensitivity;
            }

            else if (togglePlayerZoom == true)
            {
                togglePlayerZoom = false;
                FPScamera.fieldOfView = zoomedOutCamera;
                movementScript.mouseLook.XSensitivity = UnzoomedSensitivity;
                movementScript.mouseLook.YSensitivity = UnzoomedSensitivity;
            }
        }
        
    }

}
