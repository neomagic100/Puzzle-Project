using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level1 : MonoBehaviour
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
