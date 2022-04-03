using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : Item
{
    private AudioSource audioSrc;
    public Rigidbody2D rb;
    private Animator blowingAnimator;
    private bool audioPlayed;
    private bool animationPlayed;

    public Blower()
    {
        
    }
  
    // When an item collides with Blower, play sound and animation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            if (!audioPlayed)
            {
                audioSrc.Play();
            }
            
            if (!animationPlayed)
            {
                animationPlayed = true;
                
                blowingAnimator.Play("blowing_anim");
            }
            
            
        }
    }

    // When item leaves Blower, stop animation
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (animationPlayed)
        {
            blowingAnimator.enabled = false;
        }
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


        // Load blowing animation
        blowingAnimator = GetComponent<Animator>();
        

        if (blowingAnimator == null)
        {
            Debug.LogError("Cannot load ANIMATOR for the Blower Item.");
        }
        else
        {
            animationPlayed = false;
            blowingAnimator.speed = 0.9f;
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
