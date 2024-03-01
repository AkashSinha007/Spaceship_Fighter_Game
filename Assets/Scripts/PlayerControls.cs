using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;

    [Tooltip("How far player moves horizontally")][SerializeField] float xRange = 10f;
    [Tooltip("How far player moves vertically")][SerializeField] float yRange = 3.5f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;
    

    [Header("Player input based tuning")]
    
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow, yThrow;

    //public AudioSource audioSourceVariable; //Music

    // Start is called before the first frame update
    void Start()
    {
        //audioSourceVariable = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void ProcessRotation()
    {
        

        //float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;


        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll); // (x = pitch, y= yaw, z = roll)
    }

    void ProcessTranslation()
    {
        // Debug.Log(horizontalThrow);
        // Debug.Log(verticalThrow);

        //The below 2 lines for keyboard control
        // xThrow = Input.GetAxis("Horizontal");
        // yThrow = Input.GetAxis("Vertical");

        //The below 2 lines for accelerometer control
        xThrow = Input.acceleration.x;
        yThrow = Input.acceleration.y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos,-(xRange+5f),xRange);


        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos,0,yRange);
        //float clampedYPos = Mathf.Clamp(rawYPos,-yRange,yRange);

        transform.localPosition = new Vector3 (clampedXPos,clampedYPos,transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            // Debug.Log("I am Shooting");
            SetLasersActive(true);
            Handheld.Vibrate();
            // audioSourceVariable.Play();
        }
        else
        {
            // Debug.Log("I am NOT Shooting");
            SetLasersActive(false);
        }
        //If pushing Fire button 
        // then print "shooting"
        // else don't print "shooting"
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            //laser.SetActive(true);
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
