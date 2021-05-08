using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timerController : MonoBehaviour
{
    public float startTime;
    public float timer;
    public float bestTimer;

    public Text timerText;
    public Text bestTimerText;
    // Start is called before the first frame update
    private void Start()
    {
        startTime = Time.time;
        bestTimer = 999f;  
    }

    // Update is called once per frame
    private void Update()
    {
        timer = Time.time - startTime;

        timerText.text = "Timer: " + Math.Round(timer, 2);
        bestTimerText.text = "Best Time: " + Math.Round(bestTimer, 2);
    }
}
