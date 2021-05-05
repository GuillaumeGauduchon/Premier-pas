using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour
{   
    public float vitesse = 1f;
    public Transform target;
    public Transform Position1;
    public Transform Position2;
    public bool Actif = false;

    Rigidbody body;

        void Start() {
            body = GetComponent<Rigidbody>();
        
        }
        
        void OnMouseDown() {
                Actif = !Actif;

        }

        private void Update() {
            if (target != null){
                if (Actif) {
                    target.position = Vector3.MoveTowards(target.position, Position1.position, vitesse);
                }
                
                else {
                    target.position = Vector3.MoveTowards(target.position, Position2.position, vitesse);
                }
            }
        }

}
