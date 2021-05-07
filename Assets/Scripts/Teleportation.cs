using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform Tp_Target;
    public bool isKillable =false;

     public GameObject shard;
     public int count = 16;

    public void Explode() {

        if (shard == null) {
            Debug.LogWarning("Ne peut pas exploser : \"shard\" est null !!!");
            return;
        }

        for (int i = 0; i < count; i += 1) {
            GameObject clone = Instantiate(shard, Tp_Target.position, Quaternion.identity);
            Rigidbody body = clone.GetComponent<Rigidbody>();
           
            float velocityBoost = Random.Range(1f, 2f);
            body.velocity = Random.onUnitSphere * 10f * velocityBoost;

            float duration = Random.Range(1f, 2f);
            Destroy(clone, duration);
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if(Tp_Target != null) {
            other.gameObject.transform.position = Tp_Target.position;
            if (shard != null) {
                 Explode();
            }
            else {
                Debug.LogWarning("Hey n'oublie pas de mettre une shard !");
            }
        }
        
        else {
            Debug.LogWarning("Il n'y a pas de cible de téléportation !");
        }

        if (isKillable && Application.isPlaying == true) {
            Destroy(gameObject);
        }

        
    }
}