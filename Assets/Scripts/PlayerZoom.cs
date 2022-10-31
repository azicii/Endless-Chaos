using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField] Camera FPScamera;
    [SerializeField] float zoomedInCamera = 12f;
    [SerializeField] float zoomedOutCamera = 60f;

    bool togglePlayerZoom = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (togglePlayerZoom == false)
            {
                togglePlayerZoom = true;
                FPScamera.fieldOfView = zoomedInCamera;
            }

            else if (togglePlayerZoom == true)
            {
                togglePlayerZoom = false;
                FPScamera.fieldOfView = zoomedOutCamera;
            }
        }
    }

}
