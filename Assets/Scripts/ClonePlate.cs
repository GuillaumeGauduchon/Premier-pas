using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlate : MonoBehaviour
{
    public Transform cloneLocation;
    public GameObject cloneSpe;

    private void OnTriggerEnter(Collider other) {
        Vector3 position = cloneLocation.position; 
        Quaternion rotation = Quaternion.identity;
        if (cloneSpe != null) {
            Instantiate(cloneSpe, position, rotation);
        }
        else {
            Instantiate(other.gameObject, position, rotation);
        }
       
        
        transform.Find("Cube").gameObject.SetActive(false);
        transform.Find("Top").gameObject.SetActive(true);
        
        Destroy(GetComponent<Collider>());
    }
}
