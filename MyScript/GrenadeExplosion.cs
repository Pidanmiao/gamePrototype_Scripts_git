using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {

    private Collider[] hitColliders;
    public float blastRadius = 50;
    public float explosionPower = 80;
    public LayerMask explosionLayers;


    private void OnCollisionEnter(Collision collision)
    {
        ExplosionWork(collision.contacts[0].point);
        Destroy(gameObject);
    }

    void ExplosionWork(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);
        foreach(Collider hitCol in hitColliders) {
            if (hitCol.GetComponent<Rigidbody>() != null) {
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
