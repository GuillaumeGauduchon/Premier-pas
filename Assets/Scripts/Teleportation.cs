using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform Tp_Target;
    
    void OnTriggerEnter(Collider other) {
        if(Tp_Target != null) {
            other.gameObject.transform.position = Tp_Target.position;
        }
        else{
            Debug.LogWarning("Il n'y a pas de cible de téléportation !");
        }
    }
}