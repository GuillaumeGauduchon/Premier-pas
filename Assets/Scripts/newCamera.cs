using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamera : MonoBehaviour
{
    public float posx = 0;
    public float posy = 20;
    public float posz = -20;

    public GameObject controlledCube = null;
    public bool debugMod = false;
    public bool isGiant = false;
    public bool Focus = false;
    
    Transform transformCam;

     void Move() {

         if (debugMod) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && posy < 50) {
                posy += 5;
                posz += 2; 
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && posy > 5) {
                posy -= 5;
                posz -= 2; 
            }
        }

        float x = controlledCube.transform.position.x + posx;
        float y = controlledCube.transform.position.y + posy;
        float z = controlledCube.transform.position.z + posz;
        transformCam.position = new Vector3(x, y, z);
    }

     void Start() {
        transformCam = GetComponent<Transform>();
        Camera.main.transform.LookAt(controlledCube.transform);
        
        
    }

    void Update() {
        

        if (controlledCube != null) {
            if(isGiant) {
                posy = 70;
                posz = 0;
            }
            else {
                posy = 10;
                posz = -17;
            }
            Move();
            if (Focus) {
                Camera.main.transform.LookAt(controlledCube.transform);
                Focus = false;
            }
            
           
            
            
        }
    }
}
