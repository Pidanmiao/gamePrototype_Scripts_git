using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SetLayer : MonoBehaviour {

    private Item_Master itemMaster;
    public string itemThrowLayer;
    public string itemPickupLayer;

    private void OnEnable()
    {
        SetInitialReferences();
        

        itemMaster.EventObjectPickup += SetItemToPickupLayer;
        itemMaster.EventObjectThrow += SetItemToThrowLayer;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= SetItemToPickupLayer;
        itemMaster.EventObjectThrow -= SetItemToThrowLayer;
    }

    private void Start()
    {
        SetLayerOnEnable();
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void SetItemToThrowLayer()
    {
        SetLayer(transform, itemThrowLayer);
    }

    void SetItemToPickupLayer()
    {
        SetLayer(transform, itemPickupLayer);
    }

    void SetLayerOnEnable()
    {
        if(itemPickupLayer == "") {
            itemPickupLayer = "item";
        }

        if(itemThrowLayer == "") {
            itemThrowLayer = "item";
        }

        if (transform.root.CompareTag(GameManager_References._playerTag)) {
            SetItemToPickupLayer();
        }else {
            SetItemToThrowLayer();
        }
    }

    void SetLayer(Transform tForm, string itemLayerName)
    {
        tForm.gameObject.layer = LayerMask.NameToLayer(itemLayerName);

        foreach(Transform child in tForm) {
            SetLayer(child, itemLayerName);
        }
    }


}
