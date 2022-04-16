using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : Item
{
    private AudioSource audioSrc;
    public Rigidbody2D rb;
    private Animator blowingAnimator;
    private bool audioPlayed;
    private Vector2 vel = Vector2.zero;

    // Need to be Global so multiple Methods can reference it
    public GameObject target;
    private Rigidbody2D targetRb;

    // When an item collides with Blower, play sound and animation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            blowingAnimator = gameObject.GetComponent<Animator>();
                      
            if (!audioPlayed)
            {
                audioSrc.Play();
            }

            // In case there is no Target yet
            if (target == null)
                return;

            // Set velocity that the blower will send other item
            vel = new Vector2(5.5f, 0f);

            // Set the item in the trigger zone to vel - calculated when the blower has a collision
            targetRb.velocity += vel;
            
        }
    }

    // When object is in trigger zone
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            target = collision.gameObject;
            targetRb = target.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        blowingAnimator.StopPlayback();
    }


    // When item leaves Blower, stop animation
    private void OnCollisionExit2D(Collision2D collision)
    {
       blowingAnimator.StopPlayback();
    }

    // Start is called before the first frame update
    void Start()
    {     
        // Load blowing sound fx
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = AudioManager.instance.volume;

        if (audioSrc == null)
        {
            Debug.LogError("Error loading AudioSource for Blower Item");
        }
        else
        {
            audioPlayed = false;
        }
        blowingAnimator = gameObject.GetComponentInChildren<Animator>();
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
