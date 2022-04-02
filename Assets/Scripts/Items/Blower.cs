using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : Item
{
    private AudioSource audioSrc;
    public Rigidbody2D rb;
    private Animation blowingAnimation;
    [SerializeField] private Animator blowingAnimator;

    public Blower()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            audioSrc.Play();
            blowingAnimator.enabled = true;
            blowingAnimator.StartPlayback();
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

        // Load blowing animation
        blowingAnimator = GetComponent<Animator>();
        
        if (blowingAnimator == null)
        {
            Debug.LogError("Cannot load animation for the Blower item.");
        }

        blowingAnimator.enabled = false;
        /* else
         {
             // Set animation to not play automatically
             blowingAnimation.playAutomatically = false;
             blowingAnimator.SetBool("blowersheet2_1", false);
         }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
