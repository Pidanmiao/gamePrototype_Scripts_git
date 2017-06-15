using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Ammo : MonoBehaviour {

    private Item_Master itemMaster;
    private GameObject playerGO;
    public string ammoName;
    public int quantity;
    public bool isTriggerPickup;

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectPickup += TakeAmmo;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= TakeAmmo;
    }

    // Use this for initialization
    void Start () {
        SetInitialReferences();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager_References._playerTag) && isTriggerPickup) {
            TakeAmmo();
        }
    }

    void TakeAmmo()
    {
        playerGO.GetComponent<Player_Master>().CallEventPickUpAmmo(ammoName, quantity);
        Destroy(gameObject);
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
        playerGO = GameManager_References._player;

        if (isTriggerPickup) {
            if (GetComponent<Collider>() != null) {
                GetComponent<Collider>().isTrigger = true;
            }
            if (GetComponent<Rigidbody>() != null) {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
