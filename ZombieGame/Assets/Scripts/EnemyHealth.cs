using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float enemyHealth = 100f;


    public void EnemyDamage(float damagePerHit) {

        BroadcastMessage("OnDamageTaken");
        enemyHealth = enemyHealth - damagePerHit;
        if (enemyHealth < 1) {
            Destroy(gameObject);
        }
    }
}
