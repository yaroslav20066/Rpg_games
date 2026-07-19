using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Button quitButton, restartButton;
    public Canvas gameOverOverlay;

    void Start()
    {
        quitButton.onClick.AddListener(exitFunc);
        restartButton.onClick.AddListener(restartScene);
    }


    public void showGameOverScreen() {
        gameOverOverlay.GameObject().SetActive(true);   
    }

    void exitFunc() {
        Application.Quit();
    }

    void restartScene() {
        SceneManager.LoadScene("SampleScene");
    }

}