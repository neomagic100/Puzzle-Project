using UnityEngine;

public class treadmill : MonoBehaviour
{
	private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        audioSrc.volume = AudioManager.instance.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            // Play a sound effect
            audioSrc.Play();
        }
    }
	
	private void OnCollisionExit2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("Item"))
        {
            // Play a sound effect
            audioSrc.Stop();
        }
    }
}
