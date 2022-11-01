using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField] Camera FPScamera;
    [SerializeField] RigidbodyFirstPersonController movementScript;
    [SerializeField] float zoomedInCamera = 12f;
    [SerializeField] float zoomedOutCamera = 60f;
    [SerializeField] float ZoomedSensitivity = 0.5f;
    [SerializeField] float UnzoomedSensitivity = 2f;

    public bool togglePlayerZoom = false;

    void Update()
    {
        HandleZoom();
    }

    void HandleZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (togglePlayerZoom == false)
            {
                ZoomIn();
            }

            else if (togglePlayerZoom == true)
            {
                ZoomOut();
            }
        }
    }

    public void ZoomIn()
    {
        togglePlayerZoom = true;
        FPScamera.fieldOfView = zoomedInCamera;
        movementScript.mouseLook.XSensitivity = ZoomedSensitivity;
        movementScript.mouseLook.YSensitivity = ZoomedSensitivity;
    }

    public void ZoomOut()
    {
        togglePlayerZoom = false;
        FPScamera.fieldOfView = zoomedOutCamera;
        movementScript.mouseLook.XSensitivity = UnzoomedSensitivity;
        movementScript.mouseLook.YSensitivity = UnzoomedSensitivity;
    }

    void OnDisable()
    {
        ZoomOut();
    }
}
