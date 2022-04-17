using UnityEngine;

public class level3 : MonoBehaviour
{
    AudioSource audioSrc;

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
}
