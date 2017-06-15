using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavDestnationReached : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;


    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    private void Update()
    {
        if (Time.time > nextCheck) {
            CheckIfDestinationReached();
            nextCheck = Time.time + checkRate;
        }
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<NavMeshAgent>() != null) {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f, 0.4f);
    }

    void CheckIfDestinationReached()
    {
        if (enemyMaster.isOnRoute) {
            if (myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance) {
                enemyMaster.isOnRoute = false;
                enemyMaster.CallEventEnemyReachedNavTarget();
            }
        }
    }

    void DisableThis()
    {
        /*if (myNavMeshAgent != null) {
            myNavMeshAgent.enabled = false;
        }*/
        this.enabled = false;
    }
}
