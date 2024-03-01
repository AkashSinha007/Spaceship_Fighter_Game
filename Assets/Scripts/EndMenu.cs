using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using TMPro;

public class EndMenu : MonoBehaviour
{

    // UI elements to display score details
    // public TMP_Text scoreText;

    void Start()
    {
        // // Access ScoreBoard instance and update UI
        // if (ScoreBoard.Instance != null)
        // {
        //     scoreText.text = "Score: " + ScoreBoard.Instance.Score.ToString() + "\n" +
        //                      "Time: " + ScoreBoard.Instance.TimeElapsed + "\n" +
        //                      "Enemies Hit: " + ScoreBoard.Instance.NumberOfEnemiesHit.ToString();
        // }
    }
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex-1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
