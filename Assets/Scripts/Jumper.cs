using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private GameObject swipeMsg = null;
    private bool playerIsJumping = false;

    private void Update() {
        GameObject player = GameObject.FindWithTag("Player");

        if (playerIsJumping) {
            if(SwipeManager.swipeUp) {
                player.GetComponent<Controller>().Jump();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerIsJumping = true;
            other.GetComponent<Shooter>().enabled = false;
            swipeMsg.SetActive(true);
        }

        if(other.gameObject.tag == "Enemy") {
            other.GetComponent<Controller>().Jump();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerIsJumping = false;
            other.GetComponent<Shooter>().enabled = true;
            swipeMsg.SetActive(false);
        }
    }

    public bool GetCanJump() {
        return playerIsJumping;
    }
}
