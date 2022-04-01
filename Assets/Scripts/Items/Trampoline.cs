using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : Item
{
    private float bounce = 7.5f;
    private AudioSource audioSrc;


    public Trampoline()
    {

    }

    public void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            Debug.LogError("Trampoline AudioSource sound effect is null");
        }
    }

    // If an Item collides with trampoline, it will be bounced up
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            // Add a vector up with the bounce amount
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

            // Play a sound effect
            audioSrc.Play();
        }
    }
}
