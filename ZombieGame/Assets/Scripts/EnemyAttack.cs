using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] float damage = 40f;

    PlayerHealth playerHealth;

    void Start() {

        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void EnemyHitEvent() {

        playerHealth.EnemyHitsPlayer(damage);
    }
  
}
