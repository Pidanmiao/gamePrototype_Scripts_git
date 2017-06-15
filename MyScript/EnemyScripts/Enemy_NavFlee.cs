using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavFlee : MonoBehaviour {

    public bool isFleeing;
    private Enemy_Master enemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private NavMeshHit navHit;
    private Transform myTransfrom;
    public Transform fleeTarget;
    private Vector3 runPosition;
    private Vector3 directionToPlayer;
    public float fleeRange = 25;
    private float checkRate;
    private float nextCheck;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemySetNavTarget += SetFleeTarget;
        enemyMaster.EventEnemyHealthLow += IShouldFlee;
        enemyMaster.EventEnemyHealthRecovered += IShouldStopFleeing;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemySetNavTarget -= SetFleeTarget;
        enemyMaster.EventEnemyHealthLow -= IShouldFlee;
        enemyMaster.EventEnemyHealthRecovered -= IShouldStopFleeing;
    }

    private void Update()
    {
        if (Time.time > nextCheck) {
            nextCheck = Time.time + checkRate;
            CheckIfIShouldFlee();
        }
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        myTransfrom = transform;
        if (GetComponent<NavMeshAgent>() != null) {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f, 0.4f);
    }

    void SetFleeTarget(Transform target)
    {
        fleeTarget = target;
    }

    void IShouldFlee()
    {
        isFleeing = true;
        if (GetComponent<Enemy_NavPursue>() != null) {
            GetComponent<Enemy_NavPursue>().enabled = false;
        }
    }

    void IShouldStopFleeing()
    {
        isFleeing = false;
        if (GetComponent<Enemy_NavPursue>() != null) {
            GetComponent<Enemy_NavPursue>().enabled = true;
        }
    }

    bool FleeTarget(out Vector3 result)
    {
        directionToPlayer = myTransfrom.position - fleeTarget.position;
        Vector3 checkPos = myTransfrom.position + directionToPlayer;

        if(NavMesh.SamplePosition(checkPos,out navHit,1.0f, NavMesh.AllAreas)) {
            result = navHit.position;
            return true;
        }
        else {
            result = myTransfrom.position;
            return false;
        }
    }

    void CheckIfIShouldFlee()
    {
        if (isFleeing) {
            if (fleeTarget != null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused) {
                if(FleeTarget(out runPosition) && 
                    Vector3.Distance(myTransfrom.position, fleeTarget.position) <= fleeRange) {
                    myNavMeshAgent.SetDestination(runPosition);
                    enemyMaster.CallEventEnemyWalking();
                    enemyMaster.isOnRoute = true;
                }
            }
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
