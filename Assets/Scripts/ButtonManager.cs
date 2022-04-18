using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Unity References")]
    public GameObject volumeSlider;

    [Header("Unlocks")]
    public float unlocks = 1;        // 1 is Unlocked up to Level 1 -- 2 is Unlocked up to Level 2 -- so on...

    [Header("Script References")]
    private Slider slider;
        
    void Start()
    {
        slider = volumeSlider.GetComponent<Slider>();
        slider.value = AudioManager.instance.volume;

        // Loads any Saved Data
        float[] data = SaveData.LoadGame();

        if (data == null)
            return;
        unlocks = data[0];
    }

    void Update()
    {
        // Slider value is between 0 - 1 as a percentage
        AudioManager.instance.volume = slider.value;
    }

    // =============================================
    //                  Buttons
    // =============================================
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

        // Locked Unless Unlocked
        if (unlocks < 2)
            return;

        SceneManager.LoadScene(2);
    }

    public void OnLevelThree()
    {
        AudioManager.instance.Click();

        // Locked Unless Unlocked
        if (unlocks < 3)
            return;

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
