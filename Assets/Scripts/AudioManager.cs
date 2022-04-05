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

    public static float volume;

    void Awake()
    {
        instance = this;
    }
}
