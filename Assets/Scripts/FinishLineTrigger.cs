using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private Animator playerAnim = null;
    [SerializeField] private Animator enemyAnim = null;

    private DisplayUIPanels displayUIPanels;
    private bool levelEnd;

    private void Start() {
        displayUIPanels = GameObject.FindObjectOfType<DisplayUIPanels>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            PlayerLose();
            StopCharcterMover();
        }

        if(other.gameObject.tag == "Player") {
            PlayerWon();
            levelEnd = true;
            StopCharcterMover();
        }
    }

    private void PlayerWon() {
        playerAnim.SetTrigger("Won");
        enemyAnim.SetTrigger("Lose");
        StartCoroutine(GameWon());
    }

    private void PlayerLose() {
        if (Obstacles.GetGameStatus()) return;
        enemyAnim.SetTrigger("Won");
        playerAnim.SetTrigger("Lose");
        StartCoroutine(GameOver());
    }

    private void StopCharcterMover() {
        foreach(Controller controller in FindObjectsOfType<Controller>()) {
            controller.enabled = false;
        }
    }

    private IEnumerator GameOver() {
        yield return new WaitForSeconds(2f);
        displayUIPanels.DisplayGameOver();
    }

    private IEnumerator GameWon() {
        yield return new WaitForSeconds(2f);
        displayUIPanels.DisplayGameWon();
    }

    public bool GetLevelEnd() => levelEnd;
}
