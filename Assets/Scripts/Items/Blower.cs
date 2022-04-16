using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blower : Item
{
    private AudioSource audioSrc;
    public Rigidbody2D rb;
    private Animator blowingAnimator;
    private bool audioPlayed;

    // Need to be Global so multiple Methods can reference it
    public GameObject target;
    private Rigidbody2D targetRb;
    private Collider2D collider;

    // keep track of whether the iteam has been used already
    private bool itemUsed;

    // When an item collides with Blower, play sound and animation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item") && !itemUsed)
        {
            itemUsed = true;
            Debug.Log("OnCollisionEnter2D");

            blowingAnimator = gameObject.GetComponent<Animator>();
            blowingAnimator.Play("BlowingAnimation", 0, 0.01f);
                      
            if (!audioPlayed)
            {
                audioSrc.Play();
            }

            // In case there is no Target yet
            if (target == null)
            {
                // itemUsed = false;
                return;
            }
            
            // Set the new velocity of the item in the trigger zone
            setNewVelocity(collider);
        }
    }

    private void setNewVelocity (Collider2D col)
    {
        float default_x_vel = 15f;
        float default_y_vel = 0f;
        float obj_x_vel = col.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float obj_y_vel = col.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        Vector2 retVect = new Vector2(default_x_vel, default_y_vel);

        if (Math.Abs(obj_x_vel) > default_x_vel)
        {
            retVect.x *= 2;
        }

        if (Math.Abs(obj_y_vel) > default_y_vel)
        {
            retVect.y = obj_y_vel;
        }
        
        col.gameObject.GetComponent<Rigidbody2D>().velocity = retVect;
    }

    // When object is in trigger zone
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Get the item in the collision zone
        if (collision.gameObject.CompareTag("Item"))
        {
            collider = collision;
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
        itemUsed = false;

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
