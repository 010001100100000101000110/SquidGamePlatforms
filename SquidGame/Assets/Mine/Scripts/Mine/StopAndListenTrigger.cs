using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StopAndListenTrigger : MonoBehaviour
{
    //scene oottaa hetken että alottaa kuulutuksen
    [SerializeField]
    private float beginningTimer;

    private PlayerController playerController;
    private Footsteps footsteps;

    private AudioSource audioSource;       
    [SerializeField]
    private float clipTime;
    private bool clipHasPlayed;

    //light äksön alkaa tästä
    [SerializeField]
    private GameObject spotlightCollection;
    [SerializeField]
    private Light[] spotlights;
    [SerializeField]
    private float lightTimer;
    [SerializeField]
    private bool lightIsOn;    
    //valoäänet
    [SerializeField]
    private AudioClip spotlightOn;
    [SerializeField]
    private AudioClip spotlightOff;

    void Start()
    {
        //liikkumisen poistamiseen
        playerController = FindObjectOfType<PlayerController>();
        footsteps = FindObjectOfType<Footsteps>();
        playerController.isMoving = false;
        footsteps.isFootstepping = false;

        //kuulutus
        audioSource = GetComponent<AudioSource>();
        clipTime = audioSource.clip.length;
        clipHasPlayed = false;

        //spottivalot
        lightIsOn = false;
        spotlightCollection = GameObject.FindGameObjectWithTag("Platforms");
        spotlights = spotlightCollection.GetComponentsInChildren<Light>();
       
    }

    void Update()
    {     
        beginningTimer -= Time.deltaTime;
        if (beginningTimer < 0) beginningTimer = 0;
        if (beginningTimer == 0) clipTime -= Time.deltaTime;
        if (clipTime < 0) clipTime = 0;
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {  
            if (beginningTimer == 0 && clipHasPlayed == false)
            {
                audioSource.Play();
                clipHasPlayed = true;
            }

            if (clipTime == 0)
            {
                lightTimer -= Time.deltaTime;
                if (lightTimer < 0) lightTimer = 0;

                if (lightTimer > 0 && lightIsOn == false)
                {
                    TurnOnPlatformLights();
                    audioSource.PlayOneShot(spotlightOn);
                }

                if (lightTimer == 0 && lightIsOn == true)
                {
                    TurnOffPlatformLights();
                    audioSource.PlayOneShot(spotlightOff);
                    if (lightTimer == 0 && lightIsOn == false)
                        playerController.isMoving = true;
                    footsteps.isFootstepping = true;                    
                }
            }
        }           
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
        }
    }

    private void TurnOnPlatformLights()
    {        
        for (int i = 0; i < spotlights.Length; i++)
        {
            spotlights[i].enabled = true;
        }
        lightIsOn = true;
    }

    private void TurnOffPlatformLights()
    {        
        for (int i = 0; i < spotlights.Length; i++)
        {
            spotlights[i].enabled = false;
        }
        lightIsOn = false;
    }
}
