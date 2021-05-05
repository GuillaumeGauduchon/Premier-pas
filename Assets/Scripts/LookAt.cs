using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LookAt : MonoBehaviour
{
    public Transform target;
    public bool lookAtCamera = false;
    
    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            transform.LookAt(target);

        }

        if (lookAtCamera == true && Camera.main != null) {
                transform.LookAt(Camera.main.transform);
        }
    }
}
