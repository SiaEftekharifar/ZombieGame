using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float enemyHealth = 100f;

    bool isDead = false;

    public bool IsDead() {

      return isDead;
    }
    public void EnemyDamage(float damagePerHit) {

        BroadcastMessage("OnDamageTaken");
        enemyHealth = enemyHealth - damagePerHit;
        if (enemyHealth < 1) {
            Die();
        }
    }

    private void Die() {

        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
