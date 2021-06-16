using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class DisplayUIPanels : MonoBehaviour
{

    public static DisplayUIPanels instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private GameObject gameWonPanel = null;


    private void Awake() {
        instance = this;
    }

    private void Start() {
        gameOverPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void DisplayGameOver() {
        gameOverPanel.SetActive(true);
    }

    public void DisplayGameWon() {
        gameWonPanel.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit() {
        Application.Quit();
    }
    

}
