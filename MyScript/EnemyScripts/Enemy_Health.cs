using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public float enemyHealthMax = 200;
    public float enemyHealth = 100;
    public float enemyHealthLow = 25;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDeductHealth += DeductHealth;
        enemyMaster.EventEnemyIncreaseHealth += IncreaseHealth;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDeductHealth -= DeductHealth;
        enemyMaster.EventEnemyIncreaseHealth -= IncreaseHealth;
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
    }

    void DeductHealth(float healthChange)
    {
        enemyHealth -= healthChange;
        if (enemyHealth < 0) {
            enemyHealth = 0;
            enemyMaster.CallEventEnemyDie();
            Destroy(gameObject, Random.Range(10, 20));
        }else {
            CheckHealthFraction();
        }
    }

    void CheckHealthFraction()
    {
        if (enemyHealth <= enemyHealthLow && enemyHealth > 0) {
            enemyMaster.CallEventEnemyHealthLow();
        }else if (enemyHealth > enemyHealthLow) {
            enemyMaster.CallEventEnemyHealthRecovered();
        }
    }

    void IncreaseHealth(float healthChange)
    {
        enemyHealth += healthChange;
        if (enemyHealth > enemyHealthMax) {
            enemyHealth = enemyHealthMax;
        }
        CheckHealthFraction();
    }


}
