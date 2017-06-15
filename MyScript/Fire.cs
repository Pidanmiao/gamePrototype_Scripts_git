using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    private float fireRate = 0.3f;
    private float nextFire;

    public float hitForce = 100f;

    private RaycastHit hit;
    private int range = 500;

    public LayerMask bulletHoleLayer;

    private Transform myTransform;

    public GameObject bulletHolePrefab;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
        nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        CheckforInput();
	}

    void SetInitialReferences()
    {
        myTransform = transform;
    }

    void CheckforInput()
    {
        if (Time.timeScale > 0 && Input.GetButtonDown("Fire1") && Time.time > nextFire) {
            //Debug.Log("in");
            if (Physics.Raycast(myTransform.TransformPoint(0, 0, 1), myTransform.forward, out hit, range, bulletHoleLayer)) {
                Vector3 pos = hit.point;

                GameObject go = GameObject.Instantiate(bulletHolePrefab, pos, Quaternion.identity) as GameObject;
                go.transform.LookAt(hit.point - hit.normal);
                Destroy(go, 100);
            }
            nextFire = Time.time + fireRate;
        }
    }
}
