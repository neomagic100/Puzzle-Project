using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : Item
{
    private AudioSource audioSrc;
    public Rigidbody2D rb;
    private Animator blowingAnimator;
    private bool audioPlayed;
    private bool collDetected = false;
    
  
    // When an item collides with Blower, play sound and animation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collDetected = true;
        gameObject.GetComponent<BoxCollider2D>().usedByEffector = collDetected;
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            // Since it is now blowing, set the trigger zone to true
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        
            blowingAnimator = GetComponent<Animator>();
           
            if (!audioPlayed)
            {
                audioSrc.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().usedByEffector = collDetected;
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

        Debug.Log(collDetected);
    }

    private void setupEffector(PointEffector2D pe)
    {
        pe.forceSource = EffectorSelection2D.Rigidbody;
        pe.forceTarget = EffectorSelection2D.Rigidbody;
        pe.forceMagnitude = 100;
        pe.forceMode = EffectorForceMode2D.Constant;
    }
}
