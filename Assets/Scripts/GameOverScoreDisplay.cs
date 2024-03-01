using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreDisplay : MonoBehaviour
{

    //public static GameOverScoreDisplay gameOverInstance;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void Awake()
    {
        Debug.Log("GameOver is awake");
        scoreText.text = ScoreBoard.ScoreDisplayOnGameOver;
        //gameOverInstance = this;

    }

    public void DisplayScoreAtGameOverScreen(string scoreDetails)
    {
        Debug.Log("DisplayScoreAtGameOverScreen() is called");
        //gameObject.SetActive(true);
        scoreText.text = ScoreBoard.ScoreDisplayOnGameOver;
    }
}
