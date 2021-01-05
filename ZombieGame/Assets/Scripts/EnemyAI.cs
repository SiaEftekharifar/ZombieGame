using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] Transform playerTransform;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float rotationSpeed;

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

        LookAtPlayer();

        if (distanceToPlayer >= navMesh.stoppingDistance) {
            ChasePlayer();
        }else if (distanceToPlayer <= navMesh.stoppingDistance) {
            AttackPlayer();
        }

    }
    private void ChasePlayer() {
        navMesh.destination = playerTransform.position;
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);

    }

    private void AttackPlayer() {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void LookAtPlayer() {

        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
