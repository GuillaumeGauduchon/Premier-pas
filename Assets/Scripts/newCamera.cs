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
    
    Transform transformCam;

     void Move() {

         if (debugMod) {
            //Ne pas oublier d'ajouter le Target du LookAt pour une meilleure expérience du contrôle de caméra
            if (Input.GetKeyDown(KeyCode.UpArrow) && posy < 50) {
                posy += 5;
                posz += 2; 
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && posy > 5) {
                posy -= 5;
                posz -= 2; 
            }
        }

        float x = controlledCube.transform.position.x +posx;
        float y = controlledCube.transform.position.y + posy;
        float z = controlledCube.transform.position.z + posz;
        transformCam.position = new Vector3(x, y, z);
    }

     void Start() {
        transformCam = GetComponent<Transform>();
        
        
    }

    void Update() {
         if (controlledCube != null) {
                Move();

            }
    }
}
