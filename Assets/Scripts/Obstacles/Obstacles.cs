using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    private DisplayUIPanels displayGameOverPanel;

    private static bool gameOver;

    private void Start() {
        displayGameOverPanel = GameObject.FindObjectOfType<DisplayUIPanels>();
        gameOver = false;
        AdManager.instance.RequestInterstitial();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Controller>()) {
            Animator anim = other.GetComponent<Animator>();
            anim.SetTrigger("Stunned");
            other.GetComponent<Controller>().enabled = false;
            
            if(other.gameObject.tag == "Player") {
                gameOver = true;
                StartCoroutine(Gameover());
            }
        }
    }

    private IEnumerator Gameover() {
        yield return new WaitForSeconds(2f);
        AdManager.instance.ShowInterstistial();
        displayGameOverPanel.DisplayGameOver();
    }

    public static bool GetGameStatus() => gameOver;
}
