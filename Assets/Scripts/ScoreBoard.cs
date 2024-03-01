using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // public static ScoreBoard Instance;

    


    int score;
    TMP_Text scoreText;

    //To Calculate Time
    private float startTime;
    private bool finished = false;
    string minutes = "0";
    string seconds = "0";

    //Player Score based on 
    int numberOfEnemiesHit = 0;
    int numberOfStarBonusCollected = 0;


    public static string scoreDetailsAtGameOver; // Static score variable
    public static string ScoreDisplayOnGameOver
    {
        get { return scoreDetailsAtGameOver; }
        private set { scoreDetailsAtGameOver = value; }
    }
    // // Public properties to access score and time
    // public int Score => score;
    // public string TimeElapsed => minutes + ":" + seconds;
    // public int NumberOfEnemiesHit => score / 15;

    // void Awake()
    // {
    //     // Singleton pattern
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         //DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }


    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: "+ "0";

        //To capture starting point on time
        startTime = Time.time;

    }

    void Update()
    {
        if(finished)
            return;

        float t = Time.time - startTime;

        minutes = ((int) t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        //int numberOfEnemiesHit = score/15;

        scoreText.text = "Score: " + score.ToString() + "\n" 
                                   + "Enemies hit: "+ numberOfEnemiesHit.ToString() + "\n" 
                                   + "Stars Collected: "+ numberOfStarBonusCollected.ToString() + "\n" 
                                   + "Time: "+ (minutes + ":" + seconds);

        ScoreDisplayOnGameOver =  scoreText.text; 

                            
    }


    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;

        if(amountToIncrease == 10)
        {
            numberOfStarBonusCollected++;
        }
        else
        {
            numberOfEnemiesHit++;
        }
        // int numberOfEnemiesHit = score/15;

        Debug.Log($"Score is now : {score}");

        // calculateTimeTillNow();

        // scoreText.text = "Score: " + score.ToString() + "\n" 
        //                            + "Enemies hit: "+ numberOfEnemiesHit.ToString() + "\n" 
        //                            + "Time: "+ (minutes + ":" + seconds);
    }
}
