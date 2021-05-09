using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textzone : MonoBehaviour
{
    public GameObject target;

    public bool IsActive = false;

    void OnTriggerEnter(Collider other) {

        target.SetActive(!IsActive);
    }
        
    private void OnTriggerExit(Collider other) {
            target.SetActive(IsActive);
    }
    
    void Start() {
        target.SetActive(IsActive);
    }

}
