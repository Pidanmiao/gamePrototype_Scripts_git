using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SetPosition : MonoBehaviour {

    private Item_Master itemMaster;
    public Vector3 itemLocalPosition;

    private void OnEnable()
    {
        SetInitialReferences();
        
        itemMaster.EventObjectPickup += SetPositionOnLayer;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= SetPositionOnLayer;
    }

    private void Start()
    {
        SetPositionOnLayer();
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void SetPositionOnLayer()
    {
        if (transform.root.CompareTag(GameManager_References._playerTag)) {
            transform.localPosition = itemLocalPosition;
        }
    }
}
