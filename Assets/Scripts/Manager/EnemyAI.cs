using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool hasHit = true;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(hasHit) { 
            StartCoroutine(StunEnemy());
        }
    }

    private IEnumerator StunEnemy() {
        animator.SetBool("StopMoving", true);
        GetComponent<Controller>().enabled = false;
        yield return new WaitForSeconds(2f);
        GetComponent<Controller>().enabled = true;
        animator.SetBool("StopMoving", false);
        hasHit = false;
    }
}
