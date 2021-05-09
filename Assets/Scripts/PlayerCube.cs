using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    // Variables
 
    public float speed = 2f;
    public float jumpSpeed = 20f;
    
    public bool isControlled = false;
    public bool canJump = true;
    public bool IsPlayerCube = false;
    private bool isOnGround = true;
    
    Rigidbody body;

    

    void UpdateControlChild() {
        Transform child = transform.Find("Control");
        if (child != null){
            child.gameObject.SetActive(isControlled);
        }
        else {
            Debug.LogWarning("Hey mon gars, tu as oublié de nommer un Child \"Control\" !");
        }
    }

    void Move() {
        float x = speed * Input.GetAxis("Horizontal");
        float y = body.velocity.y;
        float z = speed * Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canJump && isOnGround) {
            y = jumpSpeed;
            isOnGround=false;
           
        }
        body.velocity = new Vector3(x, y, z);
    }

    // Permet de limiter le Saut à 1 (doit toucher un Objet de type Sol)
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Sol") {
            isOnGround=true;
        }
    }

    void focusCube(){
        newCamera objCam = GameObject.FindObjectOfType<Camera>().GetComponent<newCamera>();

        objCam.controlledCube = gameObject;
        objCam.Focus = true;

        if (objCam.controlledCube.tag == "Giant") {
            objCam.isGiant = true;
            
        }
        else {
            objCam.isGiant = false;
        }
        
    }

    void resetControl(){
        PlayerCube[] persos = (PlayerCube[]) GameObject.FindObjectsOfType (typeof(PlayerCube));
        foreach (PlayerCube perso in persos) {
            perso.isControlled = false;
            perso.UpdateControlChild();
        }
        
    }

    void OnMouseDown() {
        focusCube();
        resetControl();
        isControlled = true;
        UpdateControlChild();
    }

    void Start() {
        body = GetComponent<Rigidbody>();
        UpdateControlChild();
        if (IsPlayerCube) {
            focusCube();
        }
     
    }

    void Update() {
        if (isControlled == true) {
            Move();
        }
        
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerCube) {
            resetControl();
            newCamera objCam = GameObject.FindObjectOfType<Camera>().GetComponent<newCamera>();
            objCam.controlledCube = gameObject ;
            isControlled = true;
            UpdateControlChild();
            focusCube();
        }
    }
}
