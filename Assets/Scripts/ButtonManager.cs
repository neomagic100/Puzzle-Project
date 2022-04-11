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
        AudioManager.volume = slider.value; // Uncomment this once an AudioManager is established
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

    // Level Select
    public void OnLevel1Button()
    {

    }

    public void OnLevel2Button()
    {

    }

    public void OnLevel3Button()
    {

    }

    public void OnMainMenuButton()
    {

    }



}
