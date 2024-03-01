using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFiringSoundLeft : MonoBehaviour
{

    public AudioSource laserFiringSoundLeft;
    // Start is called before the first frame update
    void Start()
    {
        laserFiringSoundLeft = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessLaserFiringSoundLeft();
    }

    void ProcessLaserFiringSoundLeft()
    {
        //Debug.Log("I am Shooting from  Left Laser");
        var emissionModule = GetComponent<ParticleSystem>().emission;

        if(emissionModule.enabled )
        {
            if(!laserFiringSoundLeft.isPlaying)
            {
                laserFiringSoundLeft.Play();
            }
            
        }
        else
        {
            laserFiringSoundLeft.Stop();
        }
    }
}
