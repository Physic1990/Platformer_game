using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the audio clip
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Destroy the game object
            Destroy(this.gameObject);
        }
    }
}
