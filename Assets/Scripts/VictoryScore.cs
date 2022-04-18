using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScore : MonoBehaviour
{
    [Header("Unity References")]
    public Text score;
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
    }
}
