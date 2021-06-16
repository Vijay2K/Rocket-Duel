using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "missile") {
            GetComponent<Renderer>().material.color = Color.green;
            animator.SetTrigger("open");
            Destroy(other.gameObject);
        }
    }
}
