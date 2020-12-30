using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] Transform playerTransform;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMesh;
    float distanceToPlayer = Mathf.Infinity;
    bool isProvoked = false;
    void Start() {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update() {
        ProcessAttackToPlayer();
    }

    private void ProcessAttackToPlayer() {
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (isProvoked) {
            EngageTarget();
        }
        else if (distanceToPlayer <= chaseRange) {
            isProvoked = true;
            //  AttackPlayer();
        }
    }

    private void EngageTarget() {

        if (distanceToPlayer >= navMesh.stoppingDistance) {
            ChasePlayer();
        }else if (distanceToPlayer <= navMesh.stoppingDistance) {

            AttackPlayer();
        }

    }
    private void ChasePlayer() {
        navMesh.destination = playerTransform.position;
    }

    private void AttackPlayer() {
        print("Attack");
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
