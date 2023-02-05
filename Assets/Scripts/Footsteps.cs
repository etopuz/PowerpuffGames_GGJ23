using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    private PlayerController playerController;
    public float stepInterval = 0.5f;
    private float stepCounter;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        stepCounter -= Time.deltaTime;

        if (stepCounter <= 0)
        {
            stepCounter = stepInterval;
            if(Input.GetAxis("Horizontal") != 0 && playerController.isGrounded)
            PlayFootstepSound();
        }

    }

    private void PlayFootstepSound()
    {
        int randomIndex = Random.Range(0, footstepSounds.Length);
        AudioSource.PlayClipAtPoint(footstepSounds[randomIndex], Vector2.zero);
    }



}
