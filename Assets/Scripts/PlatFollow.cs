using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFollow : MonoBehaviour
{
    bool test = false;
    GameObject target;

    void OnCollisionStay(Collision other) {
        
        Vector3 Corrpos = other.gameObject.transform.position - gameObject.transform.position;
        target = other.gameObject;
        
    }

    private void Update() {
        if(test){
            target.gameObject.transform.position = gameObject.transform.position + Corrpos;
        }
    }
}
