using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : Item
{
    private AudioSource audioSrc;
    public Rigidbody2D rb;
    private Animator blowingAnimator;
    private bool audioPlayed;
  
    // When an item collides with Blower, play sound and animation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            blowingAnimator = GetComponent<Animator>();
           
            if (!audioPlayed)
            {
                audioSrc.Play();
            }
            
        }
    }

    // When item leaves Blower, stop animation
    private void OnCollisionExit2D(Collision2D collision)
    {
        blowingAnimator.StartPlayback();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load blowing sound fx
        audioSrc = GetComponent<AudioSource>();

        if (audioSrc == null)
        {
            Debug.LogError("Error loading AudioSource for Blower Item");
        }
        else
        {
            audioPlayed = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (audioSrc.isPlaying)
        {
            audioPlayed = true;
        }

    }
}
