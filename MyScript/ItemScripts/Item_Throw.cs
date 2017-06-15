using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Throw : MonoBehaviour {

    private Item_Master itemMaster;
    private Transform myTransform;
    private Rigidbody myRigidBody;
    private Vector3 throwDirection;

    public bool canBeThrown;
    public string throwButtonName;
    public float throwForce;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForThrowInput();
	}

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
        myTransform = transform;
        myRigidBody = GetComponent<Rigidbody>();
    }

    void CheckForThrowInput()
    {
        if (throwButtonName != null) {
            if (Input.GetButtonDown(throwButtonName) && Time.timeScale > 0
                && myTransform.root.CompareTag(GameManager_References._playerTag)) {
                CarryOutThrowActions();
            }
        }
    }

    void CarryOutThrowActions()
    {
        throwDirection = myTransform.parent.forward;
        myTransform.parent = null;
        itemMaster.CallEventObjectThrow();
        HurlItem();
    }

    void HurlItem()
    {
        myRigidBody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }
}
