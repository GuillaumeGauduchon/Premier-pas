using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassPlate : MonoBehaviour
{   
    public GameObject target;
    public GameObject shard;

    public int count = 16;
    public bool IsActive = false;

    public void Explode() {

        if (shard == null) {
            Debug.LogWarning("Ne peut pas exploser : \"shard\" est null !!!");
            return;
        }

        for (int i = 0; i < count; i += 1) {
            GameObject clone = Instantiate(shard, target.transform.position, Quaternion.identity);
            Rigidbody body = clone.GetComponent<Rigidbody>();
           
            float velocityBoost = Random.Range(1f, 2f);
            body.velocity = Random.onUnitSphere * 10f * velocityBoost;

            float duration = Random.Range(1f, 2f);
            Destroy(clone, duration);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.attachedRigidbody.mass >= 499) {
            // Debug.Log("Assez lourd");
            
            transform.Find("Cube").gameObject.SetActive(false);
            transform.Find("Top").gameObject.SetActive(true);
            target.SetActive(!IsActive);
            Explode();
        }
        else {
            Debug.Log(("L'objet a pour Mass :", other.attachedRigidbody.mass, "Ce n'est pas assez lourd"));
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.attachedRigidbody.mass >= 499) {
            transform.Find("Cube").gameObject.SetActive(true);
            transform.Find("Top").gameObject.SetActive(false);
            target.SetActive(IsActive);
            Explode();
        }
    }
    
    void Start() {
        target.SetActive(IsActive);
    }

}
