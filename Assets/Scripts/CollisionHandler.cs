using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    ScoreBoard scoreBoard;
    [SerializeField] int scoreStarBonus = 10;

    // // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // void OnCollisionEnter(Collision other )
    // {
    //     Debug.Log(this.name + "-- Collided with --" + other.gameObject.name);
    // }

    void OnTriggerEnter(Collider other )
    {
        Debug.Log($"{this.name} ** Triggered by ** {other.gameObject.name}");
        Debug.Log("CollisionHandler OnTriggerEnter..");
        if(other.gameObject.tag == "StarB")
        {
            // scoreBoard.IncreaseScore(scoreStarBonus);
            scoreBoard.IncreaseScore(scoreStarBonus);
            Destroy(other.gameObject);
        } 
        else {
            StartCrashSequence();
        }

        //StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        //Invoke("ReloadLevel", levelLoadDelay);
        Invoke("ShowGameOver", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ShowGameOver()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }

}
