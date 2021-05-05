using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiCube : MonoBehaviour
{
    void Kaboum(GameObject other) {
        Destroy(other); //agression
        Destroy(gameObject); //suicide

    }


    void OnCollisionEnter(Collision other) {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName == "FX" || layerName == "Default") {
            return;
        }

        //1. On récupère le RigidBody de "other" (tentative)
        //2. Si le RigidBody n'est pas nul (il existe) alors Kaboum

        Rigidbody otherBody = other.gameObject.GetComponent<Rigidbody>();
        if (otherBody != null) {
            Kaboum(other.gameObject);

        }
    }
}
