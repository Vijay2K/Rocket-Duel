using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Has Enter");
            Transform child = other.transform.Find("Main Camera");
            child.transform.parent = null;
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver() {
        yield return new WaitForSeconds(1f);
        DisplayUIPanels.instance.DisplayGameOver();
    }
}
