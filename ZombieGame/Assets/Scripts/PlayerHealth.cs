using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] float playerHealth = 100f;

    public void EnemyHitsPlayer(float damage) {

        playerHealth = playerHealth - damage;
        if (playerHealth <1) {
            print("Player is dead");
        }
    }
}
