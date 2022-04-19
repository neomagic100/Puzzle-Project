using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seesaw : MonoBehaviour
{
    private AudioSource audioSrc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {          
            audioSrc.Play();
        }
    }

    void Start()
    {
        // Load blowing sound fx
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = AudioManager.instance.volume;

        if (audioSrc == null)
        {
            Debug.LogError("Error loading AudioSource for Blower Item");
        }
    }
}
