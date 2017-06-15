using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleInventoryUI : MonoBehaviour {

    [Tooltip("Set true if this game has inventory")]
    public bool hasInventory;
    public GameObject InventoryUI;
    public string toggleInventoryButton;

    private GameManager_Master gameManagerMaster;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForInventoryUIToggleRequest();

    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();

        if (toggleInventoryButton == "") {
            Debug.LogWarning("Toggle inventory button needed");
            this.enabled = false;
        }

    }

    void CheckForInventoryUIToggleRequest()
    {
        if(Input.GetButtonUp(toggleInventoryButton)) {
            if (!gameManagerMaster.isMenuOn
            && !gameManagerMaster.isGameOver && hasInventory) {
                ToggleInventoryUI();
            }
        }
        
    }

    public void ToggleInventoryUI()
    {
        if (InventoryUI != null) {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
            gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
            gameManagerMaster.CallEventInventoryUIToggle();

        }
    }
}
