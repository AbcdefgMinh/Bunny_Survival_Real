using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 1800f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public float minutes;
    public float seconds;

    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.SetText(minutes + " : " + seconds);
    }
}
