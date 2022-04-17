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
        slider.value = AudioManager.instance.volume;
    }

    void Update()
    {
        // Slider value is between 0 - 1 as a percentage
        AudioManager.instance.volume = slider.value;
    }

    public void onPlayButton()
    {
        AudioManager.instance.Click();

        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        AudioManager.instance.Click();

        Debug.Log("The Application has Quit");
        Application.Quit();
    }

    public void OnMuteButton()
    {
        slider.value = 0f;
    }

    public void OnLevelOne()
    {
        AudioManager.instance.Click();

        SceneManager.LoadScene(1);
    }

    public void OnLevelTwo()
    {
        AudioManager.instance.Click();

        SceneManager.LoadScene(2);
    }

    public void OnLevelThree()
    {
        AudioManager.instance.Click();

        SceneManager.LoadScene(3);
    }

    public void OnSandBox()
    {
        AudioManager.instance.Click();

        SceneManager.LoadScene(4);
    }

    public void OnClick()
    {
        AudioManager.instance.Click();
    }
}
