using UnityEngine;

public class Piston : Item
{
    private Rigidbody2D rb;
    private PolygonCollider2D polycol;
    private AudioSource audioSrc;
    private bool audioPlayed;


    private void Awake()
    {
        audioSrc.Play();
    }

    private void OnDestroy()
    {
        audioSrc.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = AudioManager.instance.volume; 
        
        if (audioSrc == null)
        {
            Debug.LogError("Trampoline AudioSource sound effect is null");
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
    }
}
