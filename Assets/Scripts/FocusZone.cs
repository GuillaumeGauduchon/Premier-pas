using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusZone : MonoBehaviour
{
    public Transform FocusTarget;
    public bool isActive;
    public float vit = 1;
    public float ChangeX = 0;
    public float ChangeY = 0;
    public float ChangeZ = 0;
    float newPosY = 0;
    Transform cam;

    void Start() {
        newPosY = FindObjectOfType<Camera>().GetComponent<newCamera>().posy; 
        cam = FindObjectOfType<Camera>().transform;
    }

   void OnTriggerEnter(Collider other) {
        isActive = true;

   }

   void OnTriggerExit(Collider other) {
        isActive = false;
        Camera.main.transform.LookAt(other.transform);
        //new Vector3(other.transform.position.x, other.transform.position.y , other.transform.position.z)
        
   }
   private void Update() {
       if(FocusTarget != null && isActive) {
            
            //Camera.main.transform.LookAt(FocusTarget);
            //new Vector3(FocusTarget.position.x, FocusTarget.position.y + ChangeY, FocusTarget.position.z);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.LookRotation(new Vector3(FocusTarget.position.x + ChangeX, FocusTarget.position.y + ChangeY, FocusTarget.position.z + ChangeZ)), Time.deltaTime*vit);
       }
   }

}
