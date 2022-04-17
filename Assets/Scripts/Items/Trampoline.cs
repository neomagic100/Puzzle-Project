using UnityEngine;

public class Trampoline : Item
{
    public float default_bounce = 40.5f;
    private AudioSource audioSrc;


    public Trampoline()
    {

    }

    public void Start()
    { 
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = AudioManager.instance.volume;

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
            Vector2 vel = new Vector2(collision.relativeVelocity.x, default_bounce);

            // Add a vector up with the bounce amount
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(vel, ForceMode2D.Impulse);
            
            // Play a sound effect
            audioSrc.Play();
        }
    }
}
