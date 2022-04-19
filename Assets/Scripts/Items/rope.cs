using UnityEngine;

public class rope : MonoBehaviour
{
	private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("sharp"))
        {
			//Destroy(gameObject);
            // Play a sound effect
            // audioSrc.Play();
        }
    }
}
