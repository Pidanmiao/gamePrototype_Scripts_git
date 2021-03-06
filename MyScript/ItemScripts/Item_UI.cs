﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_UI : MonoBehaviour {

    private Item_Master itemMaster;
    public GameObject myUI;

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectPickup += EnableMyUI;
        itemMaster.EventObjectThrow += DisableMyUI;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= EnableMyUI;
        itemMaster.EventObjectThrow -= DisableMyUI;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void EnableMyUI()
    {
        if (myUI != null) {
            myUI.SetActive(true);
        }
    }

    void DisableMyUI()
    {
        if (myUI != null) {
            myUI.SetActive(false);
        }
    }
}
