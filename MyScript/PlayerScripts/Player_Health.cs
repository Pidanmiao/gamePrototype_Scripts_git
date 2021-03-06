﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private Player_Master playerMaster;

    public int playerHealth;
    public int maxHealth;
    public Text healthText;

	// Use this for initialization
	void Start () {
        //StartCoroutine(TestHealthDeduction());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        SetInitialReferences();
        SetUI();
        playerMaster.EventPlayerHealthDeduction += DeductHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDeduction -= DeductHealth;
        playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<Player_Master>();
    }

    IEnumerator TestHealthDeduction()
    {
        yield return new WaitForSeconds(3);
        playerMaster.CallEventPlayerHealthDeduction(1);
    }

    void DeductHealth(int healthChange)
    {
        playerHealth -= healthChange;
        if (playerHealth < 0) {
            playerHealth = 0;
            gameManagerMaster.CallEventGameOver();
        }
        SetUI();
    }

    void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;
        if (playerHealth > maxHealth) {
            playerHealth = maxHealth;
        }
        SetUI();
    }

    void SetUI()
    {
        if (healthText != null) {
            healthText.text = playerHealth.ToString();
        }
    }
}
