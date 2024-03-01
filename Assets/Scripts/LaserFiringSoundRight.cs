using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFiringSoundRight : MonoBehaviour
{

    public AudioSource laserFiringSoundRight;
    // Start is called before the first frame update
    void Start()
    {
        laserFiringSoundRight = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessLaserFiringSoundRight();
    }

    void ProcessLaserFiringSoundRight()
    {
        //Debug.Log("I am Shooting from  Right Laser");
        var emissionModule = GetComponent<ParticleSystem>().emission;

        if(emissionModule.enabled )
        {
            if(!laserFiringSoundRight.isPlaying)
            {
                laserFiringSoundRight.Play();
            }
            
        }
        else
        {
            laserFiringSoundRight.Stop();
        }
    }
}
