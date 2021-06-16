using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPath : MonoBehaviour
{
    [SerializeField] private Rigidbody block = null;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "missile") {
            block.useGravity = true;
        }    
    }

}
