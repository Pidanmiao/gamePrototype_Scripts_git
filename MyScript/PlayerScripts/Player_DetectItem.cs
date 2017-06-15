using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DetectItem : MonoBehaviour {

    public LayerMask layerToDetect;

    public Transform rayTransformPivot;

    public string buttonPickup;

    private Transform itemAvailableForPickup;
    private RaycastHit hit;
    private float detectRange = 3;
    private float detectRadius = 0.7f;
    private bool itemInRange;

    private float labelWidth = 200;
    private float labelHeight = 50;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CastRayForDetectingItems();
        CheckForItemPickupAttempt();
	}

    void CastRayForDetectingItems()
    {
        if (Physics.SphereCast(rayTransformPivot.position, detectRadius, 
            rayTransformPivot.forward, out hit, detectRange, layerToDetect)) {
            itemAvailableForPickup = hit.transform;
            itemInRange = true;
        }
        else {
            itemInRange = false;
        }

    }
    //GameManager_References._playerTag
    void CheckForItemPickupAttempt()
    {
        if(Input.GetButtonDown(buttonPickup) && Time.timeScale>0 && itemAvailableForPickup != null &&
            itemAvailableForPickup.root.tag != GameManager_References._playerTag) {
            //Debug.Log("Pickup attempted");
            itemAvailableForPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
        }
    }

    private void OnGUI()
    {
        if(itemInRange && itemAvailableForPickup != null) {
            GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight)
                , itemAvailableForPickup.name);
        }
    }
}
