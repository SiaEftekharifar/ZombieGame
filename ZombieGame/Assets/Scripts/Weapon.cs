using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour {

    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damagePerHit = 1f;

    [SerializeField] ParticleSystem gunFlashVFX;
    [SerializeField] GameObject hitEffectVFX;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float timeBetweenShoot;

    Ammo ammo;

    bool canShoot = true;

    private void OnEnable() {

        canShoot = true;
    }

    void Start() {
        ammo = FindObjectOfType<Ammo>();
    }
    void Update()
    {

       if (Input.GetMouseButtonDown(0) && canShoot == true) {
          StartCoroutine(Shoot());
       }
    }

     IEnumerator Shoot() {
         canShoot = false;

        if (ammo.CountAmmo(ammoType) > 0) {
            ProcessRayCast();
            ProcessGunFlash();
            ammo.DecreaseAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShoot);
        canShoot = true;
     }

    private void ProcessRayCast() {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.position, FPCamera.forward, out hit, range)) {
            ProcessEnemyDamage(hit);
            HitEffectVFX(hit);
        }
        else {
            return;
        }
    }

    private void ProcessEnemyDamage(RaycastHit hit) {
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target == null) { return; }
        target.EnemyDamage(damagePerHit);
    }

    private void HitEffectVFX(RaycastHit hit) {
        GameObject impact = Instantiate(hitEffectVFX, hit.point, Quaternion.identity);
        Destroy(impact, 0.1f);
    }

    private void ProcessGunFlash() {
        gunFlashVFX.Play();
    }

}
