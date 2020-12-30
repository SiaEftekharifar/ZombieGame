using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour {

    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;

    void Update()
    {
       if (Input.GetButton("Fire1")) {

           Shoot();
       }
    }

    private void Shoot() {
        RaycastHit hit;
        Physics.Raycast(FPCamera.position, FPCamera.forward, out hit, range);
        print(hit.transform.name);

    }
}
