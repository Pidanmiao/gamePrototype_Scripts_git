using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenades : MonoBehaviour {

    public GameObject grenadePrefab;
    public float propulsionForce;

    private Transform myTransform;


	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Grenade")) {
            SpawnGrenade();
        }
	}

    void SetInitialReferences()
    {
        myTransform = transform;
    }

    void SpawnGrenade()
    {
        GameObject go = Instantiate(grenadePrefab, myTransform.TransformPoint(0, 0, 0.5f), myTransform.rotation);
        go.GetComponent<Rigidbody>().AddForce(myTransform.forward * propulsionForce, ForceMode.Impulse);
    }
}
