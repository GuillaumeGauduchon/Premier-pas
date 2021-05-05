using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFollow : MonoBehaviour
{
    public GameObject Player;

    public void OnCollison(Collision other) {
        Player = other.gameObject;
        if (other.gameObject.tag == "Player")
        { 
            Player.transform.parent = this.gameObject.transform;
        }
    }

    void OnCollisionExit(Collision other) {
        Player = other.gameObject;
        Player.transform.parent = null;
    }
}