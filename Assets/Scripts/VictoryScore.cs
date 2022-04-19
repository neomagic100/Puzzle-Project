using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScore : MonoBehaviour
{
    [Header("Unity References")]
    public Text score;
    public GameObject nextLevel;
    private GameObject timerObj;
    private Timer timer;

    void Start()
    {
        timerObj = GameObject.Find("TimerText");
        timer = timerObj.GetComponent<Timer>();
    }

    void Update()
    {
        // Calculates the Score
        timer.stopTimer();
        timer.calculateScore();

        // Updates the Score
        score.text = timer.score.ToString();

        // Checks if final Level
        if (SceneManager.GetActiveScene().buildIndex == 3)
            nextLevel.SetActive(false);
    }

    // =============================================
    //                  Buttons
    // =============================================
    public void OnMainMenuButton()
    {
        // Audio
        ButtonClick();

        SceneManager.LoadScene(0);
    }

    public void OnNextLevelButton()
    {
        // Audio
        ButtonClick();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonClick()
    {
        if (AudioManager.instance == null)
            return;

        AudioManager.instance.Click();
    }
}
