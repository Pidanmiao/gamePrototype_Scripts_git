using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleCursor : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private bool isCursorLocked = true;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += ToggleCursorState;
        gameManagerMaster.InventoryUIToggleEvent += ToggleCursorState;
    }

    void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= ToggleCursorState;
        gameManagerMaster.InventoryUIToggleEvent -= ToggleCursorState;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();

    }

    void CheckIfCursorShouldLocked()
    {
        if (isCursorLocked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void ToggleCursorState()
    {
        isCursorLocked = !isCursorLocked;
    }


    // Update is called once per frame
    void Update()
    {
        CheckIfCursorShouldLocked();
    }
}
