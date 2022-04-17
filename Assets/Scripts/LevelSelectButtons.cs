using UnityEngine;

public class Button : MonoBehaviour
{
    private AudioSource audioSrc;

    private void OnMouseDown()
    {
        audioSrc.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
