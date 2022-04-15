using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : Item
{
    private float default_bounce = 6.3f;
    private AudioSource audioSrc;


    public Trampoline()
    {

    }

    public void Start()
    {
        audioSrc.volume = AudioManager.instance.volume;

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
            default_bounce *= 1.2f;
            // If the magnitude of the vector is greater than the default bounce amount, use the magnitude
            float magnitude = collision.transform.position.magnitude * 1.2f;
            float bounce = (magnitude > default_bounce) ? magnitude : default_bounce;

            // Add a vector up with the bounce amount
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            
            // Play a sound effect
            audioSrc.Play();
        }
    }
}
