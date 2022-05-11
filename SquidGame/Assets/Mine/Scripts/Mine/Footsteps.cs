using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] footsteps;
    private float timer;
    private CharacterController characterController;
    public bool isFootstepping;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        isFootstepping = true;
    }

    void Update()
    {
        if (isFootstepping) GetFootsteps();
    }

    private void GetFootsteps()
    {
        if (characterController.isGrounded == true)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                timer += Time.deltaTime;
                if (timer > 0.5f) PlayFootstep();
            }
        }
    }

    private void PlayFootstep()
    {        
        timer = 0;
        AudioClip clip = footsteps[Random.Range(0, footsteps.Length)];
        audioSource.pitch = Random.Range(0.5f, 1.5f);
        float volume = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(clip, volume);
    }
}
