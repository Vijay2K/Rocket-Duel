using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "path") {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Enemy") {
            other.GetComponent<EnemyAI>().hasHit = true;
        }
    }

}
