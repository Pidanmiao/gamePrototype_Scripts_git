using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Rigidbodies : MonoBehaviour
{

    private Item_Master itemMaster;
    public Rigidbody[] rigidBodies;

    private void OnEnable()
    {
        SetInitialReferences();
        
        itemMaster.EventObjectThrow += SetIsKinematicToFalse;
        itemMaster.EventObjectPickup += SetIsKinematicToTrue;
    }

    private void Start()
    {
        CheckIfStartsInInventory();
    }

    private void OnDisable()
    {
        itemMaster.EventObjectThrow -= SetIsKinematicToFalse;
        itemMaster.EventObjectPickup -= SetIsKinematicToTrue;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void SetIsKinematicToTrue()
    {
        if (rigidBodies.Length > 0) {
            foreach (Rigidbody rBody in rigidBodies) {
                rBody.isKinematic = true;
            }
        }
    }

    void CheckIfStartsInInventory()
    {
        if (transform.root.CompareTag(GameManager_References._playerTag)) {
            SetIsKinematicToTrue();
        }
    }

    void SetIsKinematicToFalse()
    {
        if (rigidBodies.Length > 0) {
            foreach (Rigidbody rBody in rigidBodies) {
                rBody.isKinematic = false;
            }
        }
    }
}

