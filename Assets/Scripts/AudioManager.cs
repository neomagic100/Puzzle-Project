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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Click()
    {
        buttonClick.volume = volume;
        buttonClick.Play();
    }
}
