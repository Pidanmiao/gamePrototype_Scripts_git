using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Colliders : MonoBehaviour {

    private Item_Master itemMaster;
    public Collider[] colliders;
    public PhysicMaterial myPhysicMaterial;

    private void OnEnable()
    {
        SetInitialReferences();
        
        itemMaster.EventObjectPickup += DisableColliders;
        itemMaster.EventObjectThrow += EnableColliders;
    }

    private void Start()
    {
        CheckIfStartsInInventory();
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= DisableColliders;
        itemMaster.EventObjectThrow -= EnableColliders;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
        //colliders = GetComponentInChildren<Collider>();
    }

    void CheckIfStartsInInventory()
    {
        if (transform.root.CompareTag(GameManager_References._playerTag)) {
            DisableColliders();
        }
    }

    void EnableColliders()
    {
        if (colliders.Length > 0) {
            foreach (Collider col in colliders) {
                col.enabled = true;

                if (myPhysicMaterial != null) {
                    col.material = myPhysicMaterial;
                }
            }
            
        }
    }

    void DisableColliders()
    {
        if (colliders.Length > 0) {
            foreach (Collider col in colliders) {
                col.enabled = false;
            }

        }
    }
}
