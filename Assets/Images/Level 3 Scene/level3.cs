using UnityEngine;

public class level2 : MonoBehaviour
{
    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = AudioManager.instance.volume;
        audioSrc.volume *= 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
