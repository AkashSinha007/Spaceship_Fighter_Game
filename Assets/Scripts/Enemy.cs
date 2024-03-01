using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    
    [SerializeField] int hitPoints = 1;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log($" {name} I'm hit ! by {other.gameObject.name}");

        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }

    //This script OnCollision is written to handle Star Bonus 
    // void OnCollisionEnter(Collision collision)
    // {

    // }

    void OnTriggerEnter(Collider other )
    {
        Debug.Log($"{this.name} ** Triggered by ** {other.gameObject.tag}");
        // Debug.Log("Enemy OnTriggerEnter..");
        // if(other.gameObject.tag == "StarB")
        // {
        //     Debug.Log("Enemy OnTriggerEnter..");
        //     scoreBoard.IncreaseScore(scoreStarBonus);
        //     Destroy(other.gameObject);
        // }
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX,transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
