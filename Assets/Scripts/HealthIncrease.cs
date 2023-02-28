using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthIncrease : MonoBehaviour
{
    public int healthAmount = 10; // Amount of health to increase when collected
    public AudioClip collectSound; // Sound to play when collected
    
    

    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BasePlayer baseplayer = GameObject.FindObjectOfType<BasePlayer>();
            BasePlayer player = other.GetComponent<BasePlayer>();
            if (player != null)
            {
                if(baseplayer.slider.maxValue != baseplayer.slider.value)
                {
                    player.IncreaseHealth(healthAmount); // Increase the player's health
                    AudioSource.PlayClipAtPoint(collectSound, transform.position); // Play the collect sound
                    Destroy(gameObject); // Destroy the health object
                }
                
            }
        }
    }

    
    
}
