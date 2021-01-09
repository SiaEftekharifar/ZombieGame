using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponZoom : MonoBehaviour {

    [SerializeField] Camera FPScamera;

    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float zoomedOut = 60f;

    bool zoomToggle = false;

    void Update() {
        HandleZoom();
    }

    private void HandleZoom() {

        if (Input.GetMouseButtonDown(1)) {

            if (zoomToggle == false) {
                zoomToggle = true;
                FPScamera.fieldOfView = zoomedIn;

            }
            else {
                zoomToggle = false;
                FPScamera.fieldOfView = zoomedOut;

            }
        }
    }

}


