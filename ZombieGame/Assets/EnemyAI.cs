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

    void Start() {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update() {
        ProcessDestanceToPlayer();
    }

    private void ProcessDestanceToPlayer() {
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= chaseRange) {
            AttackPlayer();
        }
    }

    private void AttackPlayer() {
        navMesh.destination = playerTransform.position;
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
