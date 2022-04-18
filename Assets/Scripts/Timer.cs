using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const int MAXSCORE = 1000;
    private Text timerText;
    private float timer;
    public float speed = 1;
    private string secondsString;
    private string minutesString;
    private string hoursString;
    public bool timerPlaying;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.color = Color.yellow;
        startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerPlaying)
        {
            timer += Time.deltaTime * speed;
            hoursString = Mathf.Floor((timer % (3600 * 60)) / 3600).ToString("00");
            minutesString = Mathf.Floor((timer % 3600) / 60).ToString("00");
            secondsString = (timer % 60).ToString("00");
            timerText.text = hoursString + ":" + minutesString + ":" + secondsString;
        }
    }

    public void startTimer()
    {
        if (!timerPlaying)
        {
            timerPlaying = true;
        }
    }

    public void stopTimer()
    {
        if (timerPlaying)
        {
            timerPlaying = false;
        }
    }

    public float getSecondsElapsed()
    {
        return timer;
    }

    public void resetTimer()
    {
        timer = 0f;
    }

    public int getScore()
    {
        calculateScore();
        return score;
    }

    public void calculateScore()
    {
        int factor;
        int timerInt = Mathf.FloorToInt(timer);

        if (120 - timerInt >= 0)
        {
            factor = 1;
        }
        if (180 - timerInt >= 0)
        {
            factor = 2;
        }
        else
        {
            factor = 3;
        }

        score = MAXSCORE - factor * timerInt;

        if (score < 0)
        {
            score = 0;
        }
    }
}
