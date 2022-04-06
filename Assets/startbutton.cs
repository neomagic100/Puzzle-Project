using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startbutton : MonoBehaviour
{
    AudioSource sfx;

    private void OnMouseDown()
    {
        sfx.UnPause();
    }

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
        sfx.loop = false;
        sfx.Pause();
    }

    // Update is called once per frame
    
}
