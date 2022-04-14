using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance;
    #endregion

    [Header("Unity References")]
    public AudioSource buttonClick;


    public float volume = 0.5f;

    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void OnButtonClick()
    {
        buttonClick.Play();
    }
}
