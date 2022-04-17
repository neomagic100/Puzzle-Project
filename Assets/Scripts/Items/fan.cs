using UnityEngine;

public class fan : Item
{
    private Rigidbody2D obj;
    public int force;

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
    private void OnTriggerStay2D (Collider2D item)
    {
        if (item.gameObject.CompareTag("Item"))
        {
            obj = item.GetComponent<Rigidbody2D>();
            obj.AddForce(new Vector2(obj.velocity.x + force, obj.velocity.y));
        }
    }
}
