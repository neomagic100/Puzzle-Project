using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Unity References")]
    public GameObject volumeSlider;

    [Header("Script References")]
    private Slider slider;

    void Start()
    {
        slider = volumeSlider.GetComponent<Slider>();
    }

    void Update()
    {
        // Slider value is between 0 - 1 as a percentage
        AudioManager.instance.volume = slider.value;
    }

    public void onPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Debug.Log("The Application has Quit");
        Application.Quit();
    }

    public void OnMuteButton()
    {
        slider.value = 0f;
    }

    public void OnLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void OnLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void OnLevelThree()
    {
        SceneManager.LoadScene(3);
    }

    public void OnSandBox()
    {
        SceneManager.LoadScene(4);
    }
}
